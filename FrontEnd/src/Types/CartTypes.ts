import { Product } from './Product'

export type CartItem = {
    product: Product;
    quantity: number;
}

export type CartPrice = {
    total: number;
    shipping: number;
    final: number;
    vat: number;
}

export const TotalPrice = (cartItem: CartItem): CartPrice => {
    const total = cartItem.product.price * cartItem.quantity;
    const shipping = 49;
    const final = total + shipping;
    const vat = final * 0.2;

    return {
        total,
        shipping,
        final,
        vat
    }
}