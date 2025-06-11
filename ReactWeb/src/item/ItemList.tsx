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
    <>
      {items.map((item: any) => (
        <div key={item.id}>
          <h2>{item.name}</h2>
          <p>{item.description}</p>
          <p>Price: ${item.price}</p>
        </div>
      ))}
    </>
  );
};

export default ItemList;
