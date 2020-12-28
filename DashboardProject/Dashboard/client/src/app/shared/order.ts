import { Customer } from './customer';

export interface Order {
    id: number;
    customer: Customer;
    totalPrice: number;
    placed: Date;
    completed: Date;
}