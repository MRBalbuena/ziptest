import { Button, Card, Divider, Image, Placeholder, Embed } from 'semantic-ui-react'
import React, { Component } from 'react'

type cardModel = {
  avatar: string;
  video: boolean;
}

const cards: cardModel[] = [
  {
    avatar: 'https://random.dog/03024628-188b-408e-a853-d97c9f04f903.jpg',
    video: false
  },
  {
    avatar: 'https://random.dog/e654dc69-29a4-4eb6-ad2d-2c18e2c67eee.jpg',
    video: false
  },
  {
    avatar: 'https://random.dog/62d87d11-bcdb-410f-8aee-324fe07f0c70.mp4',
    video: true
  },
  {
    avatar: 'https://random.dog/3b5eae93-b3bd-4012-b789-64eb6cdaac65.png',
    video: false
  },  
  {
    avatar: 'https://random.dog/a922da9a-437c-4400-9d94-f36ec2e5452c.mp4',
    video: true
  },    
  {
    avatar: 'https://random.dog/f3923c95-bad4-4dac-8de6-5adc92e5944e.webm',
    video: true
  },
  {
    avatar: 'https://random.dog/48a94bcb-75d2-46de-9f81-e37cfb574674.jpg',
    video: false
  },
  {
    avatar: 'https://random.dog/8590d98b-5839-4ec7-9065-e3aa0c2d0763.mp4',
    video: true
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
            <Card >
              {loading ? (
                <Placeholder>
                  <Placeholder.Image square />
                </Placeholder>
              ) : (card.video? (
                <Embed
                icon='right circle arrow'                
                url= {card.avatar}
                active={true}
                autoplay={true}
              />
              ): (
                <Image 
                size='medium'
                src={card.avatar} />
                )
              )}

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