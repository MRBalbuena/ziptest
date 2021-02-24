import Axios from "axios";
import { env } from "../env";

export type Guest = {
  id: string;
  firstName: string;
  lastName: string;
  created: string;
};

const api = Axios.create({
  baseURL: env.apiUrl,
});

export const getGuests = async (): Promise<Guest[]> => {
  const resp = await api.get("/guests");
  return resp.data as Guest[];
};

export const createGuest = async (
  firstName: string,
  lastName: string
): Promise<void> => {
  await api.post("/guests", {
    firstName,
    lastName,
  });
};
