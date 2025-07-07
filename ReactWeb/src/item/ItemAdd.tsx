import { useAddItem } from "../hooks/ItemHooks";
import type { Item } from "../types/Item";
import ItemForm from "./ItemForm";

const ItemAdd = () => {
  const addItemMutation = useAddItem();

  const item: Item = {
    id: 0,
    name: "",
    description: "",
    price: 0,
    imageUrl: "",
  };

  return (
    <ItemForm
      item={item}
      submitted={(item) => addItemMutation.mutate(item)}
    ></ItemForm>
  );
};

export default ItemAdd;
