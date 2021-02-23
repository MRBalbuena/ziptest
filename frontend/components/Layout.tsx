import React, { ReactNode } from "react";
import Link from "next/link";
import Head from "next/head";

type Props = {
  children?: ReactNode;
  title?: string;
};

const Layout = ({ children, title }: Props) => (
  <div>
    <Head>
      <title>{[title, "Code Test"].join(" | ")}</title>
      <meta charSet="utf-8" />
      <meta name="viewport" content="initial-scale=1.0, width=device-width" />
    </Head>
    <header>
      <nav>
        <Link href="/">
          <a>Home</a>
        </Link>{" "}
        |{" "}
        <Link href="/about">
          <a>About</a>
        </Link>{" "}
        |{" "}
        <Link href="/guestbook">
          <a>Guest Book</a>
        </Link>
      </nav>
    </header>
    {children}
    <footer>
      <hr />
      <small>&copy; Copyright 2020, Zip Co.</small>
    </footer>
  </div>
);

export default Layout;
