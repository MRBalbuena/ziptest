FROM node:14-alpine as build

COPY . .

RUN yarn

ENV NEXT_PUBLIC_API_URL="/api"

RUN yarn run build

FROM node:14-alpine

COPY --from=build package.json package.json
COPY --from=build yarn.lock yarn.lock
COPY --from=build .next .next
COPY --from=build public public

RUN yarn

EXPOSE 3000

CMD yarn start
