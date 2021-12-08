using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iLit.Infrastructure
{
    public class Node //: INode
    {
        public int ID { get; set; } //det er ikke nok med getNodeID - der skal være get/set metoder her, fordi man kan ikke
        //benytter dens values i quieries, e.g 
        [Required]
        [StringLength(50)]
        public string title { get; set; }

        
        /*public Node(string title, int? ID)
        {
            this.title = title;
            this.ID = ID;
        }*/

        /*public int getNodeID() 
        {
            return ID;//can't return null
        }

        public string getTitle()
        {
            return title;
        }

        public void IamNodeFrom()
        {
            getNodeID();
        }

        public void IamNodeTo()
        {
            getNodeID();
        }*/
    }
}
