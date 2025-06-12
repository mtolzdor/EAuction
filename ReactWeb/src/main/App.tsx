import "./App.css";
import ItemList from "../item/ItemList";
import { BrowserRouter, Route, Routes } from "react-router";
import ItemDetail from "../item/ItemDetail";

function App() {
  return (
    <BrowserRouter>
      <div className="container">
        <Routes>
          <Route path="/" element={<ItemList />}></Route>
          <Route path="house/:id" element={<ItemDetail />}></Route>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
