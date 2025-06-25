import "./App.css";
import ItemList from "../item/ItemList";
import { BrowserRouter, Route, Routes } from "react-router";
import ItemDetail from "../item/ItemDetail";
import ItemAdd from "../item/ItemAdd";
import ItemEdit from "../item/ItemEdit";

function App() {
  return (
    <BrowserRouter>
      <div className="container">
        <Routes>
          <Route path="/" element={<ItemList />}></Route>
          <Route path="item/:id" element={<ItemDetail />}></Route>
          <Route path="item/edit/:id" element={<ItemEdit />}></Route>
          <Route path="item/add" element={<ItemAdd />}></Route>
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
