import React, { Component } from 'react';
import Card from '../components/Card';
import { Pagination } from '../components/Pagination';

export class ListingPage extends Component {
  render() {
    return (
      <div className="w-full h-full flex-col">
        <div class="grid grid-cols-1 md:grid-cols-5 gap-8 p-5 md:p-6">
          <Card isEpisodeNotCharacter={true}>
          </Card>
          <Card isEpisodeNotCharacter={true}>
          </Card>
          <Card isEpisodeNotCharacter={true}>
          </Card>
          <Card isEpisodeNotCharacter={true}>
          </Card>
          <Card isEpisodeNotCharacter={true}>
          </Card>
          <Card isEpisodeNotCharacter={true}>
          </Card>
          <Card isEpisodeNotCharacter={false}>
          </Card>
          <Card isEpisodeNotCharacter={false}>
          </Card>
          <Card isEpisodeNotCharacter={false}>
          </Card>
          <Card isEpisodeNotCharacter={false}>
          </Card>
          <Card isEpisodeNotCharacter={false}>
          </Card>
          <Card isEpisodeNotCharacter={false}>
          </Card>
        </div>
        <Pagination className="w-full h-20 bg-lime-950 fixed bottom-0" />
      </div>
    );
  }
}

