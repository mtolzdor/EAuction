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

  //const { bid, setBid } = useState<Bid>(defaultBid);

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
    </>
  );
};

export default Bids;
