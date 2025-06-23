import type { Item } from "../types/Item";
import { useFetchItems } from "../hooks/ItemHook";
import { Link, useNavigate } from "react-router";

const ItemList = () => {
  const nav = useNavigate();
  const { data, isPending } = useFetchItems();

  if (isPending) return <h2>Loading...</h2>;

  return (
    <div>
      <div className="row mb-2">
        <h5 className="text-center">Items for sale</h5>
      </div>
      <table className="table table-hover">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Price</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {data &&
            data.map((item: Item) => (
              <tr key={item.id} onClick={() => nav(`/item/${item.id}`)}>
                <td>{item.id}</td>
                <td>{item.name}</td>
                <td>{item.price}</td>
                <td>
                  <img
                    className="img-thumbnail"
                    src={item.imageUrl}
                    alt="coming soon..."
                  ></img>
                </td>
              </tr>
            ))}
        </tbody>
      </table>
      <Link className="btn btn-primary" to="/item/add">
        Add
      </Link>
    </div>
  );
};

export default ItemList;
