import axios, { AxiosError, type AxiosResponse } from "axios";
import config from "../config";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import type { Item } from "../types/Item";
import { useNavigate } from "react-router";

const useFetchItems = () => {
  return useQuery<Item[], AxiosError>({
    queryKey: ["items"],
    queryFn: () =>
      axios.get(`${config.baseApiUrl}/items`).then((response) => response.data),
  });
};

const useFetchItem = (id: number) => {
  return useQuery<Item, AxiosError>({
    queryKey: ["item", id],
    queryFn: () =>
      axios
        .get(`${config.baseApiUrl}/item/${id}`)
        .then((response) => response.data),
  });
};

const useAddItem = () => {
  const queryClient = useQueryClient();
  const nav = useNavigate();
  return useMutation<AxiosResponse, AxiosError, Item>({
    mutationFn: (i) => axios.post(`${config.baseApiUrl}/items`, i),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["items"] });
      nav("/");
    },
  });
};

export { useFetchItems, useFetchItem, useAddItem };
