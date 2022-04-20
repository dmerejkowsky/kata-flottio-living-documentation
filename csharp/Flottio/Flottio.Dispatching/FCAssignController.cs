using System;
using System.Collections.Generic;

namespace Flottio.Dispatching
{
	/**
	 * The assignment of a fuel card to a driver or to a vehicle, with associated
	 * conditions of use.
	 */
	public class FCAssignController
	{
		public Dictionary<String, String> execute(VehicleAssignmentEntity vehicleAssignmentEntity)
		{
			VehicleAssignmentEntity entity = vehicleAssignmentEntity.withX();
			return null;
		}
	}
}