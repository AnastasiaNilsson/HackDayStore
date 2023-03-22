import React, { useState, useEffect } from 'react';
import { Product } from '../Types/Product';
import { getProductsAsync } from '../Services/ApiClient';
import './ProductList.css'

export const ProductList = () => {
    const [products, setProducts] = useState<Product[]>([]);
    const [searchTerm, setSearchTerm] = useState("");
    const [category, setCategory] = useState("All");

    useEffect(() => {
        const fetchData = async () => {
            setProducts(await getProductsAsync(searchTerm, category));
        }
        fetchData();
    }, [searchTerm, category]);

    const handleClick = (id: string) => {
        setCategory(id);
    }

    return (
        <main className="main">
            
            <div className="main--buttons">
                <button type="button" className="button" id="All" onClick={event => handleClick(event.currentTarget.id)}>All Categories</button>
                <button type="button" className="button" id="Nice Stuff" onClick={event => handleClick(event.currentTarget.id)}>Nice Stuff</button>
                <button type="button" className="button" id="Hot Stuff" onClick={event => handleClick(event.currentTarget.id)}>Hot Stuff</button>
                <button type="button" className="button" id="Cool Stuff" onClick={event => handleClick(event.currentTarget.id)}>Cool Stuff</button>
                <button type="button" className="button" id="Awesome Stuff" onClick={event => handleClick(event.currentTarget.id)}>Awesome Stuff</button>
            </div>
            <input className="main--search-field" type="text" id="main--search-field" placeholder="Search Products" value={searchTerm} onChange={(event) => setSearchTerm(event.target.value)} />
            
            <section className="main--list">
                {
                    products.map(product => (
                        <article className="list--product" key={product.id}>
                            <h2>{product.name}</h2>
                            <img className="list--product--image" src={product.picture} alt="Product Image" />
                            <p><b>Product Category:</b> {product.category}</p>
                            <p><b>Description:</b> {product.description}</p>
                            <p><b>Price:</b> {product.price} SEK</p>
                            <button type="button" className="button" id="All">Add to Cart</button>
                        </article>
                    ))
                }
            </section>
        </main>
    )
}
