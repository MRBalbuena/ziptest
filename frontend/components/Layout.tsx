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
        </Link>{" "}
        |{" "}        
        <Link href="/gallery">
          <a>Gallery</a>
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

const styleLink = document.createElement("link");
styleLink.rel = "stylesheet";
styleLink.href = "https://cdn.jsdelivr.net/npm/semantic-ui/dist/semantic.min.css";
document.head.appendChild(styleLink);

export default Layout;
