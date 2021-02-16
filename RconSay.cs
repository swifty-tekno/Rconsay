using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfinityScript;

namespace Rconsay
{
    public class Rconsay : BaseScript
    {
        public string sv_sayname;
        public string sv_pmsayname;

        public Rconsay() : base()
        {
            Call("setDvarifUninitialized", "sv_RconExecute", "null"); //process Rconsay

            Call("setDvarifUninitialized", "sv_sayname", "^7console: "); //public chat say prefix
            Call("setDvarifUninitialized", "sv_pmsayname", "^7PM: "); //private chat say prefix


            sv_sayname = Call<string>("getDvar", "sv_sayname");
            sv_pmsayname = Call<string>("getDvar", "sv_pmsayname");

            OnInterval(50, () =>
            {
                if (Call<string>("getDvar", "sv_RconExecute") != "null")
                {
                    string content = Call<string>("getDvar", "sv_RconExecute");
                    ProcessCommand(content);
                    Call("setDvar", "sv_RconExecute", "null");
                }
                return true;
            });
        }
        public void ProcessCommand(string message)
        {
            try
            {
                string[] msg = message.Split(' ');
                msg[0] = msg[0].ToLowerInvariant();

                if (msg[0].StartsWith("say"))
                {
                    string allchatsay = message.Remove(0, 4);
                    WriteChatToAll(allchatsay);

                    //say entref msg
                }

                if (msg[0].StartsWith("tell"))
                {
                    Entity player = GetPlayer(msg[1]);
                    string allchattell = message.Remove(0, 7);
                    WriteChatToPlayer(player, allchattell);

                    //tell entref msg
                }
            }
            catch (Exception e)
            {
                Log.Error("Error in Command Processing. Error:" + e.Message + e.StackTrace);
            }
        }

        public void WriteChatToAll(string message)
        {
            Utilities.RawSayAll(sv_sayname + " " + message);
        }

        public void WriteChatToPlayer(Entity player, string message)
        {
            Utilities.RawSayTo(player, sv_pmsayname + " " + message);
        }

        public Entity GetPlayer(string entref)
        {
            foreach (Entity player in Players)
            {
                if (player.EntRef.ToString() == entref)
                {
                    return player;
                }
            }
            return null;
        }
    }
}
