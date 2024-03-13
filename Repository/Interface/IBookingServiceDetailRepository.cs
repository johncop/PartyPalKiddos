using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IBookingServiceDetailRepository
    {
        List<BookingServiceDetail> GetAllBookingServiceDetails();
        List<BookingServiceDetail> GetAllBookingService(int bookingId);
        BookingServiceDetail GetBookingServiceDetail(int bookingId, int serviceId);
        BookingServiceDetail GetBookingPackageDetail(int bookingId, int packageId);
        void SaveBookingServiceDetail(BookingServiceDetail bookingFD);
        void SaveBookingPackageDetail(BookingServiceDetail bookingFD);
        void DeleteBookingServiceDetail(int bookingId, int serviceId);
        void DeleteBookingPackageDetail(int bookingId, int packageId);
        void UpdateBookingServiceDetail(BookingServiceDetail bookingFD);
        void UpdateBookingPackageDetail(BookingServiceDetail bookingFD);
    }
}
