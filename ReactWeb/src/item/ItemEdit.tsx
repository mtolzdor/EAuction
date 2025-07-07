import { useParams } from "react-router";
import { useFetchItem, useUpdateItem } from "../hooks/ItemHooks";
import ItemForm from "./ItemForm";

const ItemEdit = () => {
  const { id } = useParams();
  if (!id) throw Error(`Item with ${id} not found`);
  const itemId = parseInt(id);

  const { data, isSuccess, isPending } = useFetchItem(itemId);
  const updateItemMutation = useUpdateItem();

  if (isPending) return <div>Loading...</div>;
  if (!isSuccess) return <div>Error</div>;

  return (
    <ItemForm
      item={data}
      submitted={(item) => {
        updateItemMutation.mutate(item);
      }}
    ></ItemForm>
  );
};

export default ItemEdit;
