using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Exceptions;
using Restro.Models;
using Restro.Repositories;
using Restro.Services;

namespace Restro.Services
{
    public class TableBookingService : ITableBookingService
    {
        private readonly ITableBookingRepository _tableBookingRepository;

        public TableBookingService(ITableBookingRepository tableBookingRepository)
        {
            _tableBookingRepository = tableBookingRepository;
        }

        public async Task<IEnumerable<TableBooking>> GetAllTableBookingsAsync()
        {
            return await _tableBookingRepository.GetAllTableBookingsAsync();
        }

        public async Task<TableBooking> GetTableBookingByIdAsync(int id)
        {
            return await _tableBookingRepository.GetTableBookingByIdAsync(id);
        }

        public async Task<TableBooking> CreateTableBookingAsync(TableBooking tableBooking)
        {
            if (tableBooking == null)
            {
                throw new ArgumentNullException(nameof(tableBooking));
            }

            return await _tableBookingRepository.CreateTableBookingAsync(tableBooking);
        }

        public async Task UpdateTableBookingAsync(TableBooking tableBooking)
        {
            if (tableBooking == null)
            {
                throw new ArgumentNullException(nameof(tableBooking));
            }

            await _tableBookingRepository.UpdateTableBookingAsync(tableBooking);
        }

        public async Task DeleteTableBookingAsync(int id)
        {
            var tableBookingToDelete = await _tableBookingRepository.GetTableBookingByIdAsync(id);
            if (tableBookingToDelete == null)
            {
                throw new TableBookingNotFoundException($"Table booking with ID {id} not found.");
            }

            await _tableBookingRepository.DeleteTableBookingAsync(tableBookingToDelete);
        }
    }
}
