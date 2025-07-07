import { useState } from "react";
import { useAddBid, useFetchBids } from "../hooks/BidHooks";
import type { Bid } from "../types/Bid";
import type { Item } from "../types/Item";
import { currencyFormatter } from "../config";

type Props = {
  item: Item;
};

const Bids = ({ item }: Props) => {
  const { data, isPending, isSuccess } = useFetchBids(item.id);
  const addBidMutation = useAddBid();

  const defaultBid: Bid = {
    id: 0,
    itemId: item.id,
    bidderName: "",
    amount: 0,
  };

  const [bid, setBid] = useState<Bid>(defaultBid);

  const onBidSubmit = () => {
    addBidMutation.mutate(bid);
    setBid(defaultBid);
  };

  if (isPending) return <div>Loading...</div>;
  if (!isSuccess) return <div>Error loading bids</div>;

  return (
    <>
      <div className="row mt-4">
        <div className="col-12">
          <table className="table table-sm">
            <thead>
              <tr>
                <th>User</th>
                <th>Amount</th>
              </tr>
            </thead>
            <tbody>
              {data &&
                data.map((b) => (
                  <tr key={b.id}>
                    <td>{b.bidderName}</td>
                    <td>{currencyFormatter.format(b.amount)}</td>
                  </tr>
                ))}
            </tbody>
          </table>
        </div>
      </div>
      <div className="row">
        <div className="col-4">
          <input
            id="bidderName"
            className="h-100"
            type="text"
            value={bid.bidderName}
            onChange={(e) => setBid({ ...bid, bidderName: e.target.value })}
            placeholder="Name"
          ></input>
        </div>
        <div className="col-4">
          <input
            id="amount"
            className="h-100"
            type="number"
            value={bid.amount}
            onChange={(e) =>
              setBid({ ...bid, amount: parseInt(e.target.value) })
            }
            placeholder="Amount"
          ></input>
        </div>
        <div className="col-2">
          <button className="btn btn-primary" onClick={() => onBidSubmit()}>
            Submit
          </button>
        </div>
      </div>
    </>
  );
};

export default Bids;
