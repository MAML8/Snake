int width = 10, height = 10;

int[,] mapa = new int[width, height];
for(int y = 0; y<height; y++)
{
    for(int x = 0; x<width; x++)
    {
        mapa[x, y] = 0;
    }
}
Random rand = new Random();
int XPlayer = rand.Next(0,width-1), YPlayer = rand.Next(0,height-1), tamanho = 1, direcao = 0;
ConsoleKeyInfo cki = new ConsoleKeyInfo();
SpawnFruit();
while(true)
{
    while(Console.KeyAvailable == false)
    {
        Print();

        mapa[YPlayer, XPlayer] = tamanho;
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                if(mapa[x, y] > 0)
                    mapa[x, y]--;
            }
        }

        switch(direcao)
        {
            case 3:YPlayer--;break;
            case 1:YPlayer++;break;
            case 2:XPlayer--;break;
            case 0:XPlayer++;break;
            default:break;
        }
        if(YPlayer < 0)
            YPlayer = height - 1;
        else if(YPlayer >= height)
            YPlayer = 0;
        if(XPlayer < 0)
            XPlayer = width - 1;
        else if(XPlayer >= width)
            XPlayer = 0;

        if(mapa[YPlayer, XPlayer] == -1)
        {
            mapa[YPlayer, XPlayer]++;
            tamanho++;
            for(int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    if(mapa[x, y] > 0)
                        mapa[x, y]++;
                }
            }
            SpawnFruit();
        }
        else if(mapa[YPlayer, XPlayer] >= 1)
            break;

        Thread.Sleep(250);
    }
    if(mapa[YPlayer, XPlayer] >= 1)
        break;
    cki = Console.ReadKey(true);
    switch(cki.KeyChar){
        case 'w': if(direcao != 1) direcao = 3; break;
        case 's': if(direcao != 3) direcao = 1; break;
        case 'a': if(direcao != 0) direcao = 2; break;
        case 'd': if(direcao != 2) direcao = 0; break;
        default:break;
    }
}
Console.WriteLine("Você perdeu com tamanho " + tamanho + " :(");
Console.Read();

void Print()
{
    Console.Clear();
    for(int i = 0; i < width; i++)
    {
        for(int u = 0; u < height; u++)
        {
            if(u == XPlayer && i == YPlayer)
                Console.Write("O");
            else if(mapa[i,u]<0)
                Console.Write("o");
            else
                Console.Write((mapa[i, u]>=1)?"O":" ");
        }
        Console.WriteLine();
    }
}
void SpawnFruit()
{
    int xfruit, yfruit;
    do
    {
        xfruit = rand.Next(0, width - 1);
        yfruit = rand.Next(0, height - 1);
    } while(mapa[xfruit, yfruit] > 0||(xfruit==XPlayer&&yfruit==YPlayer));
    mapa[xfruit, yfruit] = -1;
}