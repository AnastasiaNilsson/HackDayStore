import { useState, useEffect } from 'react'
import reactLogo from './assets/react.svg'
import '../App.css'
import './ProductList.css'
import { ProductList } from './ProductList'

function App() {
  const [cartProducts, setCartProducts] = useState(null)

  return (
    <div className="App">
        <h2 className="Anastasia">Anastasia's</h2>
        <h1 className="MainTitle">Most Amazing Webshop Ever</h1>
        <ProductList />
    </div>
  )
}

export default App
