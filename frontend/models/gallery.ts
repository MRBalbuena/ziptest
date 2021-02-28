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

const imageExtensions: string[] = ['.jpg', '.gif', '.png'];

export const getGallery = async (): Promise<cardModel[]> => {
    // const resp = await api.get("/guests");
    //return cards as cardModel[];
    let gallery = cards.map( c => 
        ( {url: c.url, video: imageExtensions.includes(c.extension)} ) 
    );
    return gallery as cardModel[];
};


const cards: cardResponseModel[] = [
    {
        url: 'https://random.dog/03024628-188b-408e-a853-d97c9f04f903.jpg',
        extension: 'jpg'
    },
    {
        url: 'https://random.dog/e654dc69-29a4-4eb6-ad2d-2c18e2c67eee.jpg',
        extension: 'jpg'
    },
    {
        url: 'https://random.dog/62d87d11-bcdb-410f-8aee-324fe07f0c70.mp4',
        extension: 'mp4'
    },
    {
        url: 'https://random.dog/3b5eae93-b3bd-4012-b789-64eb6cdaac65.png',
        extension: 'png'
    },
    {
        url: 'https://random.dog/a922da9a-437c-4400-9d94-f36ec2e5452c.mp4',
        extension: 'mp4'
    },
    {
        url: 'https://random.dog/f3923c95-bad4-4dac-8de6-5adc92e5944e.webm',
        extension: 'webm'
    },
    {
        url: 'https://random.dog/48a94bcb-75d2-46de-9f81-e37cfb574674.jpg',
        extension: 'jpg'
    },
    {
        url: 'https://random.dog/8590d98b-5839-4ec7-9065-e3aa0c2d0763.mp4',
        extension: 'mp4'
    }
]