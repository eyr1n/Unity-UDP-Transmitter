using System.Net.Sockets;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UDPTransmitter : MonoBehaviour
{
  private UdpClient sender = new();
  private string host = "";
  private int port = 54321;

  public InputField hostField;
  public Button connectButton;
  public Text debugText;

  void Start()
  {
    connectButton.onClick.AddListener(() =>
    {
      host = hostField.text;
    });
  }

  void Update()
  {
    float x = Input.acceleration.x;
    float y = Input.acceleration.y;

    // MemoryMarshalでfloat[]をbyte[]に
    byte[] msg = MemoryMarshal.Cast<float, byte>(new float[] { x, y }).ToArray();

    // UDPで送信
    sender.SendAsync(msg, msg.Length, host, port);

    debugText.text = $"{x}\n{y}";
  }
}
