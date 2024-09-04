using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    private Camera camera;
    private SpriteRenderer backgroundRenderer;

    void Start()
    {
        camera = Camera.main;
        backgroundRenderer = GetComponent<SpriteRenderer>();

        ScaleBackground();
    }

    private void ScaleBackground()
    {
        // ابعاد دوربین
        Vector3 cameraBottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 cameraTopRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        float cameraWidth = cameraTopRight.x - cameraBottomLeft.x;
        float cameraHeight = cameraTopRight.y - cameraBottomLeft.y;

        // ابعاد پس‌زمینه
        float backgroundWidth = backgroundRenderer.bounds.size.x;
        float backgroundHeight = backgroundRenderer.bounds.size.y;

        // محاسبه مقیاس برای پوشش کامل ابعاد دوربین
        float scaleX = cameraWidth / backgroundWidth;
        float scaleY = cameraHeight / backgroundHeight;

        // انتخاب مقیاس بزرگ‌تر و تنظیم مقیاس یکنواخت برای حفظ نسبت ابعاد
        float scale = Mathf.Max(scaleX, scaleY);

        // اعمال مقیاس جدید به پس‌زمینه
        transform.localScale = new Vector3(scale, scale, 1);

        // تنظیم موقعیت پس‌زمینه برای مرکز دوربین
        Vector3 position = new Vector3(camera.transform.position.x, camera.transform.position.y, 0);
        transform.position = position;
    }
}
