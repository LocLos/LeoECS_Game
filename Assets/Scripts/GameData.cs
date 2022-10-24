using TMPro;
public class GameData
{
    public ConfigurationSO Configuration { get; private set; }

    private TMP_Text _coinCounter;
    private int _coins;

    public GameData(ConfigurationSO configuration, TMP_Text coinCounter)
    {
        Configuration = configuration;
        _coinCounter = coinCounter;
        _coins = Configuration.PlayerMoney;
    }

    public void AddCoin()
    {
        _coins++;
        _coinCounter.text = _coins.ToString();
    }
}