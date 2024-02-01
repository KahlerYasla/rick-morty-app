import React, { Component } from 'react';
import Card from '../components/Card';

export class HomePage extends Component {
  static displayName = HomePage.name;

  render() {
    return (
      <div class="grid grid-cols-1 md:grid-cols-4 gap-8 p-5 md:p-6">

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
    );
  }
}
