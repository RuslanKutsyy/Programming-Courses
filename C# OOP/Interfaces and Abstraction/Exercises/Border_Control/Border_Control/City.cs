using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Border_Control
{
    public class City
    {
        private List<Citizen> citizens;
        private List<Robot> robots;

        public City()
        {
            this.citizens = new List<Citizen>();
            this.robots = new List<Robot>();
        }

        public List<Citizen> Citizens
        {
            get { return this.citizens; }
            set { this.citizens = value; }
        }

        public List<Robot> Robots
        {
            get { return this.robots; }
            set { this.robots = value; }

        }

        public string FakeCheck(string fakeIDs)
        {

            var fakeCitizens = this.Citizens.Where(x => x.Id.EndsWith(fakeIDs)).ToArray();
            var fakeRobots = this.Robots.Where(x => x.Id.EndsWith(fakeIDs)).ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var citizen in fakeCitizens)
            {
                sb.AppendLine(citizen.Id);
            }

            foreach (var robot in fakeRobots)
            {
                sb.AppendLine(robot.Id);
            }

            return sb.ToString().Trim();
        }
    }
}
