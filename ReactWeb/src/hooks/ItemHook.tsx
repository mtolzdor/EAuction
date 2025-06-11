import axios, { AxiosError } from "axios";
import config from "../config";
import { useQuery } from "@tanstack/react-query";
import type { Item } from "../types/Item";

const useFetchItems = () => {
  return useQuery<Item[], AxiosError>({
    queryKey: ["items"],
    queryFn: () =>
      axios.get(`${config.baseApiUrl}/items`).then((response) => response.data),
  });
};

export { useFetchItems };
