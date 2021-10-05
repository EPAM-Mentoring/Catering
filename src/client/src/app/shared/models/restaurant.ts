export interface IRestaurant {
        id: number;
        name: string;
        pictureUrl: string;
        streetAddress: string;
        BookingPricePerDay : number;
        isAvailableForBooking: boolean;
        openTime: Date;
        closeTime: Date;
}