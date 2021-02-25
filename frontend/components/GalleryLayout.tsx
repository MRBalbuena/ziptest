import { Button, Card, Divider, Image, Placeholder } from 'semantic-ui-react'
import React, { Component } from 'react'

type cardModel = {
  avatar: string;
  date: string;
  header: string;
  description: string;
}

const cards: cardModel[] = [
  {
    avatar: 'https://react.semantic-ui.com/images/avatar/large/helen.jpg',
    date: 'Joined in 2013',
    header: 'Helen',
    description: 'Primary Contact',
  },
  {
    avatar: 'https://react.semantic-ui.com/images/avatar/large/matthew.png',
    date: 'Joined in 2013',
    header: 'Matthew',
    description: 'Primary Contact',
  },
  {
    avatar: 'https://react.semantic-ui.com/images/avatar/large/molly.png',
    date: 'Joined in 2013',
    header: 'Molly',
    description: 'Primary Contact',
  },
  {
    avatar: 'https://react.semantic-ui.com/images/avatar/large/molly.png',
    date: 'Joined in 2013',
    header: 'Molly',
    description: 'Primary Contact',
  },  
  {
    avatar: 'https://react.semantic-ui.com/images/avatar/large/molly.png',
    date: 'Joined in 2013',
    header: 'Molly',
    description: 'Primary Contact',
  },    
  {
    avatar: 'https://react.semantic-ui.com/images/avatar/large/helen.jpg',
    date: 'Joined in 2013',
    header: 'Helen',
    description: 'Primary Contact',
  },
  {
    avatar: 'https://react.semantic-ui.com/images/avatar/large/matthew.png',
    date: 'Joined in 2013',
    header: 'Matthew',
    description: 'Primary Contact',
  },
  {
    avatar: 'https://react.semantic-ui.com/images/avatar/large/helen.jpg',
    date: 'Joined in 2013',
    header: 'Helen',
    description: 'Primary Contact',
  }
]

export default class PlaceholderExampleCard extends Component {
  state = { loading: false }

  handleLoadingClick = () => {
    this.setState({ loading: true })

    setTimeout(() => {
      this.setState({ loading: false })
    }, 3000)
  }

  render() {
    const { loading } = this.state

    return (
      <>
        <Button loading={loading} onClick={this.handleLoadingClick} primary>
          Simulate loading
        </Button>
        <Divider />

        <Card.Group doubling itemsPerRow={4} stackable>
          {cards.map((card: cardModel) => (
            <Card key={card.header}>
              {loading ? (
                <Placeholder>
                  <Placeholder.Image square />
                </Placeholder>
              ) : (
                <Image src={card.avatar} />
              )}

              <Card.Content>
                {loading ? (
                  <Placeholder>
                    <Placeholder.Header>
                      <Placeholder.Line length='very short' />
                      <Placeholder.Line length='medium' />
                    </Placeholder.Header>
                    <Placeholder.Paragraph>
                      <Placeholder.Line length='short' />
                    </Placeholder.Paragraph>
                  </Placeholder>
                ) : (
                  <>
                    <Card.Header>{card.header}</Card.Header>
                    <Card.Meta>{card.date}</Card.Meta>
                    <Card.Description>{card.description}</Card.Description>
                  </>
                )}
              </Card.Content>

              <Card.Content extra>
                <Button disabled={loading} primary>
                  Add
                </Button>
                <Button disabled={loading}>Delete</Button>
              </Card.Content>
            </Card>
          ))}
        </Card.Group>
      </>
    )
  }
}


/*
function GalleryLayout() {
  return (
    <div className="flex-container">

      <li className="flex-item">1</li>
      <li className="flex-item">2</li>
      <li className="flex-item">3</li>
      <li className="flex-item">4</li>
      <li className="flex-item">5</li>
      <li className="flex-item">6</li>

    </div>
  );
}

export default GalleryLayout;
*/