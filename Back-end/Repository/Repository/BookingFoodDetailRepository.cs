using BusinessObject.Models;
using DataAccess; // Assume DataAccess contains appropriate methods
using Repository.Interface;
using System.Collections.Generic;

namespace Repository.Repository
{
    public class BookingFoodDetailRepository : IBookingFoodDetailRepository
    {
        public List<BookingFoodDetail> GetAllBookingFoodDetails() => BookingFoodDetailDAO.GetAllBookingFoodDetails();
        public List<BookingFoodDetail> GetAllBookingFood(int bookingId) => BookingFoodDetailDAO.GetAllBookingFood(bookingId);
        public BookingFoodDetail GetBookingComboDetails(int bookingId, int comboId) => BookingFoodDetailDAO.GetBookingComboDetails(bookingId, comboId);

        public BookingFoodDetail GetBookingFoodDetails(int bookingId, int foodId) => BookingFoodDetailDAO.GetBookingFoodDetails(bookingId, foodId);

        public void SaveBookingFoodDetail(BookingFoodDetail bookingFD) => BookingFoodDetailDAO.SaveBookingFoodDetail(bookingFD);

        public void SaveBookingComboDetail(BookingFoodDetail bookingFD) => BookingFoodDetailDAO.SaveBookingComboDetail(bookingFD);

        public void DeleteBookingFoodDetail(int bookingId, int foodId) => BookingFoodDetailDAO.DeleteBookingFoodDetail(bookingId, foodId);

        public void DeleteBookingComboDetail(int bookingId, int comboId) => BookingFoodDetailDAO.DeleteBookingComboDetail(bookingId, comboId);

        public void UpdateBookingFoodDetail(BookingFoodDetail bookingFD) => BookingFoodDetailDAO.UpdateBookingFoodDetail(bookingFD);

        public void UpdateBookingComboDetail(BookingFoodDetail bookingFD) => BookingFoodDetailDAO.UpdateBookingComboDetail(bookingFD);
    }

}
