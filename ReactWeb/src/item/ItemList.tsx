import axios from "axios";
import { useEffect, useState } from "react";
import type { Item } from "../types/Item";

const ItemList = () => {
  const [items, setItems] = useState<Item[]>([]);

  useEffect(() => {
    const fetchItems = async () => {
      await axios
        .get(`https://localhost:4000/items`)
        .then((response) => setItems(response.data));
    };
    fetchItems();
  }, []);
  return (
    <div>
      <div className="row mb-2">
        <h5 className="themeFontColor text-center">Items for sale</h5>
      </div>
      <table className="table table-hover">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Description</th>
            <th>Price</th>
          </tr>
        </thead>
        <tbody>
          {items.map((item: any) => (
            <tr key={item.id}>
              <td>{item.id}</td>
              <td>{item.name}</td>
              <td>{item.description}</td>
              <td>{item.price}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ItemList;
