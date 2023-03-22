import { Product } from "../Types/Product";



export const getProductsAsync = async (searchTerm: string, category: string): Promise<Product[]> => {
    let url = "https://localhost:1337/api/products";

    if (category != "All" || searchTerm != "") {
        url += "?";
    }
    if (category != "All") {
        url += `category=${category}`;
    }
    if (searchTerm != "") {
        if (category != "All") {
            url += `&`;
        }
        url += `searchTerm=${searchTerm}`;
    }
    return await fetch(url).then(response => response.json());
}