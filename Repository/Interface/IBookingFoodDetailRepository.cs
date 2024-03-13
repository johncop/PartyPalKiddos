using BusinessObject.Models;
using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IBookingFoodDetailRepository
    {
        List<BookingFoodDetail> GetAllBookingFoodDetails();
        List<BookingFoodDetail> GetAllBookingFood(int bookingId);
        BookingFoodDetail GetBookingComboDetails(int bookingId, int comboId);
        BookingFoodDetail GetBookingFoodDetails(int bookingId, int foodId);
        void SaveBookingFoodDetail(BookingFoodDetail bookingFD);
        void SaveBookingComboDetail(BookingFoodDetail bookingFD);
        void DeleteBookingFoodDetail(int bookingId, int foodId);
        void DeleteBookingComboDetail(int bookingId, int comboId);
        void UpdateBookingFoodDetail(BookingFoodDetail bookingFD);
        void UpdateBookingComboDetail(BookingFoodDetail bookingFD);
    }

}
