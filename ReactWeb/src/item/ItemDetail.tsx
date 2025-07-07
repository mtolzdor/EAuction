import Bids from "../bids/Bids";
import { useDeleteItem, useFetchItem } from "../hooks/ItemHooks";
import { Link, useParams } from "react-router";

const ItemDetail = () => {
  const { id } = useParams();
  if (!id) throw Error("Item id not found");
  const itemId = parseInt(id);

  const { data, isSuccess, isPending } = useFetchItem(itemId);
  const deleteItemMutation = useDeleteItem();

  if (isPending) return <div>Loading...</div>;
  if (!isSuccess) return <div>Error</div>;
  if (!data) return <div>Item not found</div>;

  return (
    <div className="row">
      <div className="col-6">
        <div className="row">
          <img className="img-fluid" src={data.imageUrl}></img>
        </div>
        <div className="row mt-3">
          <div className="col-2">
            <Link className="btn btn-primary" to={`/item/edit/${data.id}`}>
              Edit
            </Link>
          </div>
          <div className="col-2">
            <button
              className="btn btn-danger"
              onClick={() => {
                if (
                  window.confirm("Are you sure you want to delete this item?")
                ) {
                  deleteItemMutation.mutate(data);
                }
              }}
            >
              Delete
            </button>
          </div>
        </div>
      </div>
      <div className="col-6">
        <div className="row mt-2">
          <h5 className="col-12">{data.name}</h5>
        </div>
        <div className="row">
          <h3 className="col-12">{data.price}</h3>
        </div>
        <div className="row">
          <h3 className="col-12 mt-3">{data.description}</h3>
        </div>
        <Bids item={data} />
      </div>
    </div>
  );
};

export default ItemDetail;
