using System.Collections.Generic;

namespace Flottio.Dispatching
{
    /**
	* The optimization of the assignment of all resources over time to minimize
	* cost according to various constraints. The input is a schedule of requested
	* tasks, and the output is the planning as a collection of resources (vehicles,
	* fuel cards) assignments over a period of time.
*/
    public class DispatchingOptimizationService
    {

        private FCAssignController controller;
        private VehicleAssignmentEntity vehicleAssignmentEntity;

        public IDictionary<string, string> perform(IDictionary<string, string> inputTable)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            int index = 0;
            index = ForEachDriverCell(inputTable, dictionary, index);
            return dictionary;
        }

        // Need a lot of comments here cause the optimization is totally generic and is hard to read
        // TODO add more documentation here!
        public int ForEachDriverCell(IDictionary<string, string> inputTable, Dictionary<string, string> Dictionary, int index)
        {
            foreach (KeyValuePair<string, string> entry in inputTable)
            {
                string key = entry.Key;
                string value = entry.Value;
                if (key.StartsWith("DRIVER_"))
                {
                    Dictionary.Add(key + index, value);
                }
                index++;
            }
            return index;
        }

        public FCAssignController getController()
        {
            return controller;
        }

        public void setController(FCAssignController controller)
        {
            this.controller = controller;
        }

        public VehicleAssignmentEntity getVehicleAssignmentEntity()
        {
            return vehicleAssignmentEntity;
        }

        public void setVehicleAssignmentEntity(VehicleAssignmentEntity vehicleAssignmentEntity)
        {
            this.vehicleAssignmentEntity = vehicleAssignmentEntity;
        }



    }
}