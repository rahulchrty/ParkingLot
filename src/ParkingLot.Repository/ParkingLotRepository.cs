using ParkingLot.Model;
using ParkingLot.RepositoryInterfaces;
using System;

namespace ParkingLot.Repository
{
    public class ParkingLotRepository : IParkingLotRepository
    {
        private VehicleDetailsModel[] _storage;
        public void CreateParkingSlots(int numberOfSlots)
        {
            try
            {
                _storage = new VehicleDetailsModel[numberOfSlots];
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int ParkVehicle(VehicleDetailsModel vehicleDetail, int index)
        {
            try
            {
                _storage[index] = vehicleDetail;
                return index;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int GetEmptySlotIndex()
        {
            int emptyIndex = 0;
            try
            {
                emptyIndex = Array.IndexOf(_storage, null);
            }
            catch (Exception ex)
            {
                throw;
            }
            return emptyIndex;
        }
        public void EmptyASlot(int index)
        {
            try
            {
                _storage[index] = null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int TotalSlotAllocated()
        {
            try
            {
                int slots = _storage.Length;
                return slots;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
