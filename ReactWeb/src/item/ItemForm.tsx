import { useState } from "react";
import type { Item } from "../types/Item";

type Props = {
  item: Item;
  submitted: (item: Item) => void;
};

const ItemForm = ({ item, submitted }: Props) => {
  const [itemState, setItemState] = useState<Item>({ ...item });

  const onSubmit: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
    e.preventDefault();
    submitted(itemState);
  };

  return (
    <form className="mt-2">
      <div className="form-group">
        <label htmlFor="name">Name</label>
        <input
          type="text"
          className="form-control"
          placeholder="Name"
          value={itemState.name}
          onChange={(e) => setItemState({ ...itemState, name: e.target.value })}
        ></input>
      </div>
      <div className="form-group mt-2">
        <label htmlFor="description">Description</label>
        <textarea
          className="form-control"
          placeholder="Description"
          value={itemState.description}
          onChange={(e) =>
            setItemState({ ...itemState, description: e.target.value })
          }
        ></textarea>
      </div>
      <div className="form-group mt-2">
        <label htmlFor="price">Price</label>
        <input
          type="number"
          className="form-control"
          placeholder="Price"
          value={itemState.price}
          onChange={(e) =>
            setItemState({ ...itemState, price: parseInt(e.target.value) })
          }
        ></input>
      </div>
      <button className="btn btn-primary mt-2" onClick={onSubmit}>
        Submit
      </button>
    </form>
  );
};

export default ItemForm;
