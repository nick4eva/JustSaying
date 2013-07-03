using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimplesNotificationStack.Messaging.Messages;
using SimplesNotificationStack.Messaging.Messages.CustomerCommunication;
using SimplesNotificationStack.Messaging.Messages.OrderDispatch;

namespace SimplesNotificationStack.Messaging.MessageSerialisation
{
    public class ReflectedMessageSerialisationRegister : IMessageSerialisationRegister
    {
        private Dictionary<string, IMessageSerialiser<Message>> _map;

        public ReflectedMessageSerialisationRegister()
        {
            _map = new Dictionary<string, IMessageSerialiser<Message>>();

            // ToDo: reflect this somehow!

            //var list = from t in Assembly.GetExecutingAssembly().GetTypes()
            //           where t.BaseType == (typeof (Message)) && t.GetConstructor(Type.EmptyTypes) != null
            //           select new {Key = t, Value = new NewtonsoftSerialiser<t>()};

            _map.Add(typeof(CustomerOrderRejectionSms).ToString(), new NewtonsoftSerialiser<CustomerOrderRejectionSms>());
            _map.Add(typeof(CustomerOrderRejectionSmsFailed).ToString(), new NewtonsoftSerialiser<CustomerOrderRejectionSmsFailed>());

            _map.Add(typeof(OrderAccepted).ToString(), new NewtonsoftSerialiser<OrderAccepted>());
            _map.Add(typeof(OrderAlternateTimeSuggested).ToString(), new NewtonsoftSerialiser<OrderAlternateTimeSuggested>());
            _map.Add(typeof(OrderRejected).ToString(), new NewtonsoftSerialiser<OrderRejected>());
        }

        public IMessageSerialiser<Message> GetSerialiser(string objectType)
        {
            return _map[objectType];
        }
    }
}