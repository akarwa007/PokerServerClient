using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Poker.Shared;

namespace Poker.Server
{
    public class Card : A_Card
    {
        
        public Card(Suit s, Rank r):base(r,s)
        {
            this.Suit = s;
            this.Rank = r;
            
        }
        public Card():base()
        {
            
        }
       
    }
   
}
