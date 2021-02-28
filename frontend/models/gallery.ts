import Axios from "axios";
import { env } from "../env";


export type cardResponseModel = {
    url: string;
    extension: string;
}

export type cardModel = {
    url: string;
    video: boolean;
}

const api = Axios.create({
    baseURL: env.apiUrl,
});

const imageExtensions: string[] = ['.jpg', '.gif', '.png', '.jpeg'];

export const getGallery = async (): Promise<cardModel[]> => {
    const resp = await api.get("/gallery");    
    let gallery = resp.data.map( c => 
        ( {url: c.url, video: !imageExtensions.includes(c.extension)} ) 
    );    
    return gallery as cardModel[];
};
