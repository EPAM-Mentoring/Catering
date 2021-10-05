export interface IBookingToCreate {
    restaurantId: number;
}

export interface IBooking {
    id: number;
    customerMail: string;
    bookingDate: string;
    bookingItems: IBookingItem[];
  }
  
  export interface IBookingItem {
    restaurantId: number;
    restaurantName: string;
    pictureUrl: string;
    BookingPricePerDay: number;
    openTime: Date;
    closeTime: Date;
  }