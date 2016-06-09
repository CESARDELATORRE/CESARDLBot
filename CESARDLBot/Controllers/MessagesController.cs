
using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;


//(OLD-BreakingChange?) using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;

namespace CESARDLBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public async Task<Message> Post([FromBody]Message message)
        {
            return await Conversation.SendAsync(message, () => new PersonalDataProviderDialog());
        }

        // ------  to send a message 
        // ConnectorClient botConnector = new BotConnector();
        // ... use message.CreateReplyMessage() to create a message, or
        // ... create a new message and set From, To, Text 
        // await botConnector.Messages.SendMessageAsync(message);

        /*
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                // calculate something for us to return
                int length = (message.Text ?? string.Empty).Length;

                // return our reply to the user
                //return message.CreateReplyMessage($"You sent {length} characters");

                if(message.Text.Contains("Cesar"))
                    return message.CreateReplyMessage($"Jo! I know you Cesar! U'r so cool! ;)");
                else
                    return message.CreateReplyMessage($"You said: {message.Text} --- Bot Demo");
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        */

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}