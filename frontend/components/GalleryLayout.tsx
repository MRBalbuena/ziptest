import { Button, Card, Divider, Image, Placeholder, Container } from 'semantic-ui-react'
import React, { Component } from 'react'
import { cardModel, getGallery } from "../models/gallery";
import { flashError } from "../utils";


export default class GalleryLayout extends Component {
  state = { loading: false }
  cards: cardModel[] = [];

  loadGallery = async () => {
    try {
      this.cards = await getGallery();
      this.setState({ loading: false })
    } catch (e) {
      flashError(e);
    }
  };

  handleLoadingClick = () => {
    this.setState({ loading: true })

    this.loadGallery();

  }

  render() {
    const { loading } = this.state

    return (
      <>
        <Button loading={loading} onClick={this.handleLoadingClick} primary>
          Load Gallery
        </Button>
        <Divider />

        <Container>

          <Card.Group doubling itemsPerRow={4} stackable>
            {this.cards.map((card: cardModel) => (
              <Card>
                {loading ? (
                  <Placeholder>
                    <Placeholder.Image square />
                  </Placeholder>
                ) : (card.video ? (
                  <video
                    src={card.url}
                    autoPlay={true}
                    loop={true}
                  />
                ) : (
                    <Image
                      size='large'
                      src={card.url} />
                  )
                )}
              </Card>
            ))}
          </Card.Group>
        </Container>
      </>
    )
  }
}
