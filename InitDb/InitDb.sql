CREATE TABLE "message_event" (
    "id" SERIAL PRIMARY KEY,
    "sender_id" UUID NOT NULL,
    "receiver_id" UUID NOT NULL,
    "chat_id" UUID NOT NULL,
    "chat_name" VARCHAR NOT NULL,
    "sender_name" VARCHAR NOT NULL,
    "receiver_name" VARCHAR NOT NULL,
    "created_at" VARCHAR NOT NULL,
    "message" VARCHAR NOT NULL
);

CREATE TABLE "call_event" (
     "id" SERIAL PRIMARY KEY,
     "sender_id" UUID NOT NULL,
     "receiver_id" UUID NOT NULL,
     "sender_name" VARCHAR NOT NULL,
     "receiver_name" VARCHAR NOT NULL,
     "created_at" VARCHAR NOT NULL
);

CREATE TABLE "invite_event" (
      "id" SERIAL PRIMARY KEY,
      "sender_id" UUID NOT NULL,
      "receiver_id" UUID NOT NULL,
      "sender_name" VARCHAR NOT NULL,
      "receiver_name" VARCHAR NOT NULL,
      "created_at" VARCHAR NOT NULL
);