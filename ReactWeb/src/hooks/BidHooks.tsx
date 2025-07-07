import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import type { AxiosError, AxiosResponse } from "axios";
import type { Bid } from "../types/Bid";
import config from "../config";
import axios from "axios";

const useFetchBids = (itemId: number) => {
  return useQuery<Bid[], AxiosError>({
    queryKey: ["bids", itemId],
    queryFn: () =>
      axios
        .get(`${config.baseApiUrl}/item/${itemId}/bids`)
        .then((res) => res.data),
  });
};

const useAddBid = () => {
  const queryClient = useQueryClient();
  return useMutation<AxiosResponse, AxiosError, Bid>({
    mutationFn: (b) =>
      axios.post(`${config.baseApiUrl}/item/${b.itemId}/bids`, b),
    onSuccess: (_, b) => {
      queryClient.invalidateQueries({
        queryKey: ["bids", b.itemId],
      });
    },
  });
};

export { useFetchBids, useAddBid };
