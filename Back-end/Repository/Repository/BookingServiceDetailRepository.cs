using BusinessObject.Models;
using DataAccess;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class BookingServiceDetailRepository : IBookingServiceDetailRepository
    {
        public List<BookingServiceDetail> GetAllBookingServiceDetails() => BookingServiceDetailDAO.GetAllBookingServiceDetails();
        public List<BookingServiceDetail> GetAllBookingService(int bookingId) => BookingServiceDetailDAO.GetAllBookingService(bookingId);
        public BookingServiceDetail GetBookingServiceDetail(int bookingId, int serviceId) => BookingServiceDetailDAO.GetBookingServiceDetails(bookingId, serviceId);

        public BookingServiceDetail GetBookingPackageDetail(int bookingId, int packageId) => BookingServiceDetailDAO.GetBookingPackageDetails(bookingId, packageId);

        public void SaveBookingServiceDetail(BookingServiceDetail bookingFD) => BookingServiceDetailDAO.SaveBookingServiceDetail(bookingFD);

        public void SaveBookingPackageDetail(BookingServiceDetail bookingFD) => BookingServiceDetailDAO.SaveBookingPackageDetail(bookingFD);

        public void DeleteBookingServiceDetail(int bookingId, int serviceId) => BookingServiceDetailDAO.DeleteBookingServiceDetail(bookingId, serviceId);

        public void DeleteBookingPackageDetail(int bookingId, int packageId) => BookingServiceDetailDAO.DeleteBookingPackageDetail(bookingId, packageId);

        public void UpdateBookingServiceDetail(BookingServiceDetail bookingFD) => BookingServiceDetailDAO.UpdateBookingServiceDetail(bookingFD);

        public void UpdateBookingPackageDetail(BookingServiceDetail bookingFD) => BookingServiceDetailDAO.UpdateBookingPackageDetail(bookingFD);
    }
}
