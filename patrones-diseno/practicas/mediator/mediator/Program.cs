using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatRoom s = new ChatRoom();

            User juan = new User(s);
            juan.Name = "Juan";
            s.register(juan);

            User pedro = new User(s);
            pedro.Name = "Pedro";
            s.register(pedro);

            User jorge = new User(s);
            jorge.Name = "Jorge";
            s.register(jorge);

            juan.Sends("Pedro", "Hey! Hola. Quieres jugar lol? uwu");
            pedro.Sends("Juan", "Claro. Ahorita me conecto.");
            jorge.Sends("Juan", "Ey! Hombre. Cómo estás?");

            Console.ReadKey();
        }

        public interface IChatUser
        {
            void Receives(string from, string msg);
            void Sends(string to, string msg);
        }

        public class User : IChatUser
        {
            private string name;
            private ChatRoom ChatRoom;

            public User(ChatRoom ChatRoom)
            {
                this.ChatRoom = ChatRoom;
            }

            public virtual void Receives(string from, string msg)
            {
                string s = "User <" + from + "> says: " + msg;
                Console.WriteLine(name + ": " + s);
            }
            public virtual void Sends(string a, string msg)
            {
                ChatRoom.send(name, a, msg);
            }
            public virtual string Name
            {
                get { return name; }
                set { this.name = value; }
            }
        }

        public interface IChatRoom
        {
            void register(User user);
            void send(string from, string to, string msg);
        }

        public class ChatRoom : IChatRoom
        {
            private Dictionary<string, User> users = new Dictionary<string, User>();
            public virtual void register(User user)
            {
                users[user.Name] = user;
            }

            public virtual void send(string from, string to, string msg)
            {
                if (users.ContainsKey(from) && users.ContainsKey(to))
                {
                    User u = users[to];
                    u.Receives(from, msg);
                }
                else
                {
                    Console.WriteLine("User not found");
                }
            }
        }
    }
}
