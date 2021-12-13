# programa-de-bolsas-compasso

# Atividade 2 Sprint 3

# Descrição da atividade:

No projeto há 4 arquivos no formato json que possuem dados fragmentados. Quando juntos poderão informar dados de uma pessoa, sua música favorita, o ano da música favorita, outras músicas do gosto dessa pessoa e uma lista com os artistas e todas suas músicas que relacionam com as músicas desta pessoa.

O objetivo do exercício é juntar todas as informações e preencher uma lista com objetos com a classe "Output" (Output.cs). Ao total deverão ter 88 registros. Todas as informações de cada objeto "Output" deverão estar preenchidas. Não há nulos.

Por fim deverá ser gerado um arquivo .json com todos os objetos no output.
# Requisitos

  * Há uma animação sendo executada na thread principal. Toda a lógica para gerar o resultado final deverá ser feita sem interromper a animação.
  * Deverá utilizar a classe "Database" para consumir os dados
  * Poderá utilizar Tasks, Parallel ou pLinq

# Exemplo de Resultado Final
```json
{
    "PersonName": "Gary Ortiz",
    "PersonAge": 50,
    "FavoriteSong": "Free Fallin'",
    "FavoriteSongArtist": "Tom Petty",
    "FavoriteSongYear": 1989,
    "OtherSongs": [ "King of Spain", "New Realization", "American Girl", "American Music", "Flapper Girl", "High and Dry", "Danny Boy", "Moonshadow", "Little Talks", "Party in the USA", "Summer of '69", "The Mother We Share", "The Weight" ],
    "ArtistSongs": [
      {
        "Artist": {
          "Id": 41,
          "Name": "Of Monsters and Men"
        },
        "Songs": [
          {
            "Id": 98,
            "Name": "Little Talks",
            "Year": 2012,
            "ArtistId": 41
          }
        ]
      }
   ]
},
      
      (...................)
```
# Dicas
[<img src="https://c.tenor.com/NPJgF7_j7RAAAAAM/dungeons-and-dragons-dungeon-master.gif">]()
* O básico as vezes é mais eficiente que o complexo
* Try/Catch pode não ser muito amigável em produção, mas é um grande amigo para debugar
* Flags booleanas podem ser grandes aliadas nesta aventura!


```
B7UU2U5U1UF2122j10OU2U2U2U1U2U1U1U2U1U1U1U2U2u1MGUUUF1SSXSSU525U1JO
G                                                                 .
B            .:.                                  .,,             :
B          .,,                                       :.    . .    :
B         ,,                       :                  ::          :
B        :.         ...:.  ..  .,   ,.   .   ,         .:         :
B       :.          , r  :: i,.  ::  ..  .,   :          i        i
B  .   :.        , ,.:.   iv . ,:..:..:;  ..  .:         .i       :
B     ,,    ..  i  i,r     .ui.  ir,  rUJ  r.  ,.     .   .:      i
B    .i     :  i: ..7:      .ir.  ,i:  .:7,.L,  :     ,  . :.     :
B    :.   , : .r . :2         .     :7:.  u:,r: ,  .  :. .: r     :
B  . i  . . . .:., ,:              LU.     i, u,:: :   ;  r :.    :
B   .: ,.. :i .,7                  .,         .:75  .  :. :..:    i
B ..,. ; . ri. .U .i:.                           rU..  .: .i i    :
B . :. 7  :.L,  .,:,;Y                            vr, . i  i :.   i
B  ..:,7  : 7U                                    :...  :. i ,.   :
B ...r:, iS  :                                    :   . :. :.,:   i
B .. L:. YM                                   ..  :  .  ,: :.:i   :
B ...i. iru                            :XMBBBBBBB:: . . .. :..i   i
M    i. ,rr.                          rBBBBBBB,5B.:. .  ., i ,:   i
B    ,:.  ::        .:..:             .:BBM0OL 7r i  .. ,, : :.   r
M    ::. .:.,    ,1BBBBBBB              :GS7rvL.  :.,:,:,..: i    i
B    ,i.  i i   qBBBBBBM1B.                       ::.  :: ,.,:  . ;
M    ::.  :. i .qUBBMBM. ;     .                  7:   7. . :     i
B    ::.  ,: .:   NBY77rr     iU                  Y.  ,v.  :.     i
B ...i.:   i  :                     .r            j.  ir.,:,      i
B ...i:r   ,: ,,              i71YLjFNi           u   ::Yi.       i
B ...::Y,   ,, :              :BBYvL7Ur       .. .L   i:i         :
B ..,.i:;.  .: :               .k7v7LU7      :..:Yi   :.          i
B  ....J.i. 7::L:.              .kjJjX.      :   :L:.  .::        :
B   .  :7 :,:::7Y::.             .vL7      .iE:   r.  .  .:       i
M  .       .:7  :::i7v.,..             .:2ZOYJU  i  .:.   .:      :
B   .        .  .  .:i  ..,.,.i7,.iiq8BBB0YiirL ., :.   .  :.     i
B              .....         :.  7vrFJ7rii:i;LL  :i, .:.   ,.     :
B             ....... .     :.  ,J7ir:iirrvLLi;   ,:.:     ., .   i
M              ..... .      :  i :r7r777rr:.   i    ii  i, ; . .  :
B             . . . . .    .: :i....,..        .i    .::. i.  .   i
M                           v,       .....      :        r        :
B         . .              ,i   . . .   ..:::.  i.      ,J    .   i
```
