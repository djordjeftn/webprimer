using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentationLayerWeb
{
    public partial class _Default : Page
    {
        private TeamBusiness teamBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
         
            this.teamBusiness = new TeamBusiness();

            List<Team> teams = this.teamBusiness.GetAllTeams();

            listBoxTeams.Items.Clear();
            foreach (Team t in teams)
            {
                listBoxTeams.Items.Add(t.Id + ". " + t.Name + " " + t.Couch + " - " + t.Points);
            }
        }
    }
}