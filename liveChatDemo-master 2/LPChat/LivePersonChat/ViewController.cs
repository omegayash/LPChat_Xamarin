using System;
using ChatBinding;
using UIKit;
using Foundation;
 
 namespace LivePersonChat
{
    public partial class ViewController : UIViewController
    {
        ConversationParamProtocol conversationQuery;
        NSError error = null;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           // NSError error = null;
            LPConversationViewParams viewParams;
            // Perform any additional setup after loading the view, typically from a nib.
           
          //  ChatBinding.ILPMessagingSDK lPMessagingSDK = new  LPMessagingSDK ();


            conversationQuery = LPMessagingSDK.Instance.GetConversationBrandQuery("33136087", null);
            if(conversationQuery.ActiveConversation !=null)
            LPMessagingAPI.ClearConversationFromDB(conversationQuery.ActiveConversation);
             
         //  var a= LPMessagingAPI.GetAllClosedConversations(NSDate.Now);
            //LPMessagingAPI.OpenAllSockets();
           
          //  LPMessagingSDK.Instance.RemoveConversation(conversationQuery );
            

            btnInit.TouchUpInside += (o, s) =>
            {
              



                LPMessagingSDK.Instance.ClearHistory(conversationQuery, out error);
                viewParams = new LPConversationViewParams((ConversationParamProtocol)conversationQuery, null, false, null);
                LPMessagingSDK.Instance.ResolveConversation(conversationQuery);


                LPMessagingSDK.Instance.ShowConversation(viewParams, null);
            };

            LPMessagingAPI.ClearHistory(conversationQuery);
        }
        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            LPMessagingAPI.CloseAllSockets();
            
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        

    }

   
}
