using CommunityToolkit.Mvvm.Messaging.Messages;
using SupermercadoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermercadoApp.Class
{
    class Message : ValueChangedMessage<string>
    {
        public Producto ProductoAEditar { get; set; }

        public Message(string value) : base(value)
        {

        }
    }
}
