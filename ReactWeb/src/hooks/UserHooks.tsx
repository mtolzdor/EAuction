import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import type { Claim } from "../types/Claim";
import { AxiosError } from "axios";
import axios from "axios";
import config from "../config";
import { useNavigate } from "react-router";

const useFetchUser = () => {
  return useQuery<Claim[], AxiosError>({
    queryKey: ["user"],
    queryFn: () =>
      axios
        .get(`${config.baseApiUrl}/account/getuser?slide=false`)
        .then((response) => response.data),
  });
};

const useLogOutUser = () => {
  const queryClient = useQueryClient();
  const nav = useNavigate();
  return useMutation<AxiosError>({
    mutationFn: () => axios.post(`${config.baseApiUrl}/account/logout`),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["user"] });
      nav("/");
    },
  });
};

export { useFetchUser, useLogOutUser };
